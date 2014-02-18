
namespace Scraper
{
    public interface IWriter<in T>
    {
        void Write(T data);
    }
}
