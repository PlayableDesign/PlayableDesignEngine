namespace PlayableDesign.Events
{
    [System.Serializable]
    public class EmptyArg
    {
        public static EmptyArg EMPTY => new EmptyArg();

        public override string ToString()
        {
            return "";
        }
    }
}
