
namespace Service4u2.Common
{
    public class EventArgs<TArgType> : System.EventArgs
    {
        public TArgType Argument { get; set; }
    }
}
