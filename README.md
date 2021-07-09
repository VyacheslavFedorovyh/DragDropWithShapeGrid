# Drag'n drop With any Shape Grid

A prototype project with some logic:
- Selecting ships for placing modules
- The shape of the ship's mesh can be any
- You can place a module on the ship's grid only if it fits completely into the grid.
- If, when a new module is placed on the grid, the new module occupies cells already occupied by another module, then the previous module is removed (freeing the cells occupied by it).

After clicking the button to complete the build:
- Display a message if there are empty cells
- Go to the initial screen with saving the assembly. Saving is implemented within the session.
