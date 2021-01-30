namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    internal class TextPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "TextProperty";

        private int _Id;
        public  int  Id { get => _Id; set => Set(ref _Id, value); }

        private string _Uuid;
        public  string  Uuid { get => _Uuid; set => Set(ref _Uuid, value); }

        private string _Content;
        public  string  Content { get => _Content; set => Set(ref _Content, value); }
        

        public TextPropertyViewModel(string attrName, UassetLib.TextProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Id      = prop.Id;
            Uuid    = prop.Uuid;
            Content = prop.Content;
        }
    }
}