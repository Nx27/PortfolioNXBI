using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Portfolio.Logic.CS
{
  public class SubBarController
  {
    public event Action? ReRenderRequested;
    public bool IsVisible = true;
    public List<string> SubBarContentLinks = new();
    /// <summary>
    /// Set SubBar component visible
    /// RemoveSubBar() should be called on dispose
    /// </summary>
    /// <param name="Titles">The content of the SubBar</param>
    public void SetSubBarContent(params string[] Titles)
    {
      IsVisible = true;
      SubBarContentLinks = Titles.ToList();
      ReRenderRequested?.Invoke();
    }
    /// <summary>
    /// Call this at component dispose
    /// </summary>
    public void RemoveSubBar()
    {
      IsVisible = false;
      SubBarContentLinks.Clear();
      ReRenderRequested?.Invoke();
    }
  }
}
