using FirstMVCApp.DataContext;
using FirstMVCApp.Repositories;


namespace FirstMVCApp.RepoUnitOfWork
{
    public class UnitOfWork
    {
        private AnnouncementsRepository _announcementsRepository;
        private CodeSnippetRepository _codeSnippetRepository;
        private MembershipsRepository _membershipsRepository;
        private MembershipTypesRepository _membershipTypesRepository;
        private MembersRepository _membersRepository;
        private readonly ClubDataContext _context;

        public UnitOfWork(ClubDataContext context)
        {
            _context = context;
        }

        public AnnouncementsRepository AnnouncementsRepository
        {
            get
            {
                if (_announcementsRepository is null)
                {
                    _announcementsRepository = new AnnouncementsRepository(_context);
                }
                return _announcementsRepository;
            }
            private set { }
        }

        public CodeSnippetRepository CodeSnippetRepository
        {
            get
            {
                if (_codeSnippetRepository is null)
                {
                    _codeSnippetRepository = new CodeSnippetRepository(_context);
                }
                return _codeSnippetRepository;
            }
        }

        public MembershipsRepository MembershipsRepository
        {
            get
            {
                if (_membershipsRepository is null)
                {
                    _membershipsRepository= new MembershipsRepository(_context);
                }
                return _membershipsRepository;
            }
        }

        public MembershipTypesRepository MembershipTypesRepository
        {
            get
            {
                if (_membershipTypesRepository is null)
                {
                    _membershipTypesRepository= new MembershipTypesRepository(_context);
                }
                return _membershipTypesRepository;
            }
        }

        public MembersRepository MembersRepository
        {
            get
            {
                if (_membersRepository is null)
                {
                    _membersRepository = new MembersRepository(_context);
                }
                return _membersRepository;
            }
        }
    }
}
