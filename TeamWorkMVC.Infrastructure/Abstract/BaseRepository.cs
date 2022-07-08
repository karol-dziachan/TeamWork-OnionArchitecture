namespace TeamWorkMVC.Infrastructure.Abstract;

public class BaseRepository : IBaseRepository
{
    protected readonly Context _context;

    public BaseRepository(Context context)
    {
        _context = context;
    }
}