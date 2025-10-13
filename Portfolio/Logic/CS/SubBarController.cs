using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Portfolio.Logic.CS
{
  public class SubBarController
  {
    public bool IsVisible => SubBarText.Count > 0;
    public List<string> SubBarText = new();
    List<string> SubBarTextBuffer = new();

    public SubBarController(NavigationManager navigationManager) =>
      navigationManager.LocationChanged += (sender, args) => SubBarText.Clear();



    public void BuildSubBar()
    {
      SubBarText.Clear();
      SubBarText.AddRange(SubBarTextBuffer);
      SubBarTextBuffer.Clear();
    }

    public string RegisterElementID(string displayName)
    {
      SubBarTextBuffer.Add(displayName);
      return $"{SubBarTextBuffer.Count}+{displayName}";
    }
  }
}
