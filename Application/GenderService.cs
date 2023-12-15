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

        //this function will return true if succesful,false if it is not success
        //input parameter id is the identifier of the gender that will be updated
        //input parameter dto is the info of the gender that will update the existing info of the gender
        //-> dto input param is the new content
        public bool UpdateGender(int id, GenderDto genderDto)
        {      

            //find the gender by id
            Gender? getGender = _repository.GetGenderById(id);
            if (getGender == null)
            {
                return false;
            }
            else
            {
                //the info of the dto will overwrite the info of the getGender that is                             found
                getGender.Id = genderDto.Id;
                getGender.Name = genderDto.Name;
                    

                _repository.UpdateGender(getGender);
   
                return true;
            }
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
