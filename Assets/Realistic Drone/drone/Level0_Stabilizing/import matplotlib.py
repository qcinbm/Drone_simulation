import matplotlib.pyplot as plt
from matplotlib.patches import FancyBboxPatch

# Create the figure and axis
fig, ax = plt.subplots(figsize=(10, 7))

# Define positions for the blocks in the diagram
positions = {
    "Desired State": (0.1, 0.8),
    "Current State\n(from Sensors)": (0.1, 0.6),
    "Error Calculation": (0.5, 0.7),
    "PID Control\n(P, I, D)": (0.7, 0.6),
    "Motor Adjustments": (0.5, 0.4),
    "Drone Movement": (0.3, 0.2),
    "Stabilized Drone": (0.7, 0.2),
}

# Draw the blocks using FancyBboxPatch for rounded corners
def draw_block(text, position, width=0.25, height=0.1):
    box = FancyBboxPatch((position[0] - width / 2, position[1] - height / 2),
                         width, height, boxstyle="round,pad=0.1", edgecolor="black", facecolor="lightblue")
    ax.add_patch(box)
    ax.text(position[0], position[1], text, ha="center", va="center", fontsize=12)

# Draw all blocks
for label, pos in positions.items():
    draw_block(label, pos)

# Draw arrows between the blocks
arrowprops = dict(facecolor='black', arrowstyle="->")

ax.annotate("", xy=positions["Error Calculation"], xytext=positions["Desired State"], arrowprops=arrowprops)
ax.annotate("", xy=positions["Error Calculation"], xytext=positions["Current State\n(from Sensors)"], arrowprops=arrowprops)
ax.annotate("", xy=positions["PID Control\n(P, I, D)"], xytext=positions["Error Calculation"], arrowprops=arrowprops)
ax.annotate("", xy=positions["Motor Adjustments"], xytext=positions["PID Control\n(P, I, D)"], arrowprops=arrowprops)
ax.annotate("", xy=positions["Drone Movement"], xytext=positions["Motor Adjustments"], arrowprops=arrowprops)
ax.annotate("", xy=positions["Stabilized Drone"], xytext=positions["Drone Movement"], arrowprops=arrowprops)

# Set axis limits and remove axes
ax.set_xlim(0, 1)
ax.set_ylim(0, 1)
ax.axis('off')

# Show the diagram
plt.title("PID Control System for Drone Stabilization", fontsize=16)
plt.show()
