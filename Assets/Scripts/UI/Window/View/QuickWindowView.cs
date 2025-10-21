namespace BelousovGameDev.UI.Window.View
{
    using global::UI.Window.View;

    public class QuickWindowView : AbstractWindowView
    {
        public override void UpdateView()
        {
            CanvasGroup.blocksRaycasts = Window.IsVisible;
            CanvasGroup.interactable = Window.IsVisible;
            CanvasGroup.alpha = Window.IsVisible ? MaxAlpha : MinAlpha;
        }
    }
}