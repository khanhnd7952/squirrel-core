using Squirrel.UGUI.SimpleButton;

namespace Squirrel.UGUI
{
    public class KButtonClose : KButton
    {
        private PanelUI _panel;

        private void Awake()
        {
            _panel = GetComponentInParent<PanelUI>();
        }

        protected override void OnClick()
        {
            base.OnClick();
            _panel.InternalClickClose();
        }
    }
}