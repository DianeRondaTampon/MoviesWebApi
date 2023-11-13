using MoviesWebApi.Models;
using MoviesWebApi.Repositories;

namespace MoviesWebApi.Application
{
    public class DirectorService
    {
        private readonly DirectorRepository _repository;

        public DirectorService(DirectorRepository repository)
        {
            _repository = repository;
        }

        public List<Director> GetAllDirector()
        {
            return _repository.GetAllDirector();
        }

        public Director? GetDirectorById(int id)
        {
            //Director diane= _repository.GetDirectorById(id);
            //bool isNULL = diane == null;
            //bool isVeryNull = _repository.GetDirectorById(id) == null;

            //if(_repository.GetDirectorById(id)==null)
            //{
            //    //is null ->doesn't exist
            //}
            //else
            //{
            //    //is a director exist
            //}

            return _repository.GetDirectorById(id);
        }

        public Director CreateDirector(Director director)
        {
            _repository.AddDirector(director);
            return director;
        }

       

        public bool UpdateDirector(int id, Director director)
        {
            if (_repository.GetDirectorById(id) == null)
                return false;

            director.Id = id;
            _repository.UpdateDirector(director);
            return true;
        }

        public bool DeleteDirector(int id)
        {
            if (_repository.GetDirectorById(id) == null)
                return false;

            _repository.DeleteDirector(id);
            return true;
        }
    }
}
