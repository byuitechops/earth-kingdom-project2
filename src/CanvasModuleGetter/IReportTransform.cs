
namespace CanvasModuleGetter
{
    // I figured that we could use the Factory Pattern in our program. Not sure if it's a good idea or not.
    // Evgeniy: Seems good to me
    public interface IReportTransform
    {
        //void transformer(dynamic data);
        void transform();
        void printReportType();
    }

}