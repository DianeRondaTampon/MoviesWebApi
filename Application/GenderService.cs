using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;

namespace MoviesWebApi.Application
{
    public class GenderService
    {
        private readonly GenderRepository _repository;

        public GenderService(GenderRepository repository)
        {
            _repository = repository;
        }

        public List<GenderDto> GetAllGenders()
        {
            List<Gender> genders = _repository.GetAllGender();
            List<GenderDto> genderDtos = new List<GenderDto>();
            foreach (Gender gender in genders)
            {
                GenderDto genderDto = new GenderDto()
                {
                    Id = gender.Id,
                    Name = gender.Name,                    
                };
                genderDtos.Add(genderDto);
            }
            return genderDtos;
        }

 
        public Gender? GetGenderById(int id)
        {
            return _repository.GetGenderById(id);
        }

        public Gender CreateGender(Gender gender)
        {
            _repository.AddGender(gender);
            return gender;
        }

        

        public bool UpdateGender(int id, Gender gender)
        {
            if (_repository.GetGenderById(id) == null)
                return false;

            gender.Id = id;
            _repository.AddGender(gender);
            return true;
        }

        public bool DeleteGender(int id)
        {
            if (_repository.GetGenderById(id) == null)
                return false;

            _repository.DeleteGender(id);
            return true;
        }
    }
}
