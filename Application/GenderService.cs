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
         
 
        public GenderDto? GetGenderById(int id)
        {
            Gender? gender = _repository.GetGenderById(id);
            //is a gender and i need a gendrdto

            if (gender != null)
            {
                GenderDto genderDto = new GenderDto()
                {
                    Id = gender.Id,
                    Name = gender.Name,
                };

                return genderDto;
            }
            else
            {
                return null;
            } 
        }

        public GenderDto CreateGender(GenderDto genderDto)
        {
            Gender gender = new Gender()
            {
                Id = genderDto.Id,
                Name = genderDto.Name,
            };
       
            Gender genderCreated = _repository.AddGender(gender);
            GenderDto genderCreatedDto = new GenderDto()
            {
                Id = genderCreated.Id,
                Name = genderCreated.Name
            };

            return genderCreatedDto;
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
