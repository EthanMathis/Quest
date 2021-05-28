namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription { get; set; }

        public Hat(int shine)
        {
            string Description;
            if (shine < 2)
            {
                Description = "dull";
            }
            else if (shine >= 2 && shine <= 5)
            {
                Description = "noticeable";
            }
            else if (shine >= 6 && shine <= 9)
            {
                Description = "bright";
            }
            else
            {
                Description = "blinding";
            }

            ShininessLevel = shine;
            ShininessDescription = Description;
        }
    }
}