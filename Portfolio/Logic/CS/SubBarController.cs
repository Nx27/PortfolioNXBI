using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Portfolio.Logic.CS
{
  public class SubBarController
  {
    public event Action? ReRenderRequested;
    public bool IsVisible = true;
    public List<string> SubBarContentLinks = new();
    private bool awaitNavigation = true;

    public SubBarController(NavigationManager navigationManager) =>
      navigationManager.LocationChanged += (sender, args) => 
      {
        SubBarContentLinks.Clear();
        IsVisible = false;
        ReRenderRequested?.Invoke();
        awaitNavigation = false;
      };



    public async void SetSubBarContent(params string[] Titles)
    {
      if (IsVisible == true) return;
      
      await Task.Run(() =>
      {
        while (awaitNavigation)
        {
          
          Task.Delay(100);
        }

      });

      awaitNavigation = true;
      IsVisible = true;
      SubBarContentLinks = Titles.ToList();
      ReRenderRequested?.Invoke();
    }
  }
}
