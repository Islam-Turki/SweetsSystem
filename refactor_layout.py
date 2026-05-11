import os
import re

dialogs_dir = r"c:\Users\islam\OneDrive\Desktop\newSystem - Copy\SweetsSystemInGitHub\SweetsSystem\Dialogs"
files = [f for f in os.listdir(dialogs_dir) if f.endswith("Dialog.Designer.cs") and f != "BaseDialog.Designer.cs"]

for file in files:
    path = os.path.join(dialogs_dir, file)
    with open(path, "r", encoding="utf-8") as f:
        lines = f.readlines()
        
    controls_y = {}
    
    # Pass 1: find Y coordinates
    for line in lines:
        m = re.search(r'^\s*(?:this\.)?(\w+)\.Location = new.*Point\(\d+, (\d+)\);', line)
        if m:
            name, y = m.groups()
            if name != "bottomPanel":
                controls_y[name] = int(y)
                
    # Sort by Y coord
    sorted_controls = sorted(controls_y.items(), key=lambda x: x[1])
    
    new_lines = []
    in_add_block = False
    
    for line in lines:
        # Drop Location
        if re.search(r'^\s*(?:this\.)?\w+\.Location = new.*Point\(', line):
            if "bottomPanel" not in line:
                continue
                
        # Drop SetChildIndex
        if re.search(r'^\s*(?:this\.)?Controls\.SetChildIndex', line):
            continue
            
        # Catch Controls.Add
        m = re.search(r'^\s*(?:this\.)?Controls\.Add\((?:this\.)?(\w+)\);', line)
        if m:
            if m.group(1) != "bottomPanel":
                in_add_block = True
                continue # drop the old Add
            
        if in_add_block and "Name =" in line:
            # End of block, inject
            for name, y in sorted_controls:
                new_lines.append(f"            this.mainLayout.Controls.Add(this.{name});\n")
            in_add_block = False
            
        new_lines.append(line)
        
    with open(path, "w", encoding="utf-8") as f:
        f.writelines(new_lines)
    print(f"Processed {file}")
