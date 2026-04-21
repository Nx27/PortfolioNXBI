namespace Portfolio.Logic.CS
{
  public class FontChanger
  {
    public event Action? OnChange;
    private bool _altFont;
    public bool AltFont
    {
      get => _altFont;
      set
      {
        if (_altFont == value) return;
        _altFont = value;
        OnChange?.Invoke();
      }
    }
  }
}
