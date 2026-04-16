using Microsoft.JSInterop;

namespace Portfolio.Logic.CS
{
  public class DetectPhone(IJSRuntime js) : IDisposable
  {
    private readonly IJSRuntime js = js;

    public async ValueTask<bool> isMobileUserAgent() =>
        await js.InvokeAsync<bool>("isMobileUserAgent");

    // Calling SuppressFinalize(this) prevents derived types that introduce 
    // a finalizer from needing to re-implement IDisposable.
    public void Dispose() => GC.SuppressFinalize(this);
  }
}