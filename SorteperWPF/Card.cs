namespace SorteperWPF
{
    public class Card
    {
        public int Value { get; set; }


        private string Suit;

        public string suit
        {
            get { return Suit; }
            set { Suit = value; }
        }


        private string ImgName;

        public string imgName
        {
            get { return ImgName; }
            set { ImgName = value; }
        }


        public Card(int value)
        {
            Suit = suit;
            Value = value;
            ImgName = imgName;
        }
    }
}
