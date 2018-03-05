namespace RSUI.BA.Rating.Data.Entities
{
    public class PolicySymbol
    {
        private int symbolSkey = 0;
        private string code;
        private string desc;


        public virtual int SymbolSkey
        {
            get { return symbolSkey; }
            set { symbolSkey = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

    }
}
