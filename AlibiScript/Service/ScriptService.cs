using AlibiScript.Interface;
using AlibiScript.Model;
using AlibiScript.ViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Service
{
    public class ScriptService : IScriptService
    {
        private readonly IRepository<Scripts> script_repo;
        private readonly IRepository<Characters> character_repo;
        private readonly IRepository<Users> user_repo;
        private readonly IRepository<ScriptImages> scriptImg_repo;

        public ScriptService(IRepository<Scripts> scriptRepo, IRepository<Characters> characterRepo, IRepository<Users> userRepo, IRepository<ScriptImages> scriptImgRepo)
        {
            script_repo = scriptRepo;
            character_repo = characterRepo;
            user_repo = userRepo;
            scriptImg_repo = scriptImgRepo;
        }
        public bool CreateScript(ScriptViewModel scriptVM, string account)
        {
            try
            {
                Guid userId = user_repo.GetAll().FirstOrDefault(x => x.Account == account).Id;

                Scripts script = new Scripts
                {
                    Id = Guid.NewGuid(),
                    Name = scriptVM.Name,
                    Intro = scriptVM.Intro,
                    Difficulty = scriptVM.Difficulty,
                    CreateTime = DateTime.Now,
                    IsPlace = scriptVM.IsPlace,
                    Price = int.Parse(scriptVM.Price),
                    Time = int.Parse(scriptVM.Time),
                    Tags = string.Join('&', scriptVM.Tags),
                    PlayerNum = int.Parse(scriptVM.PlayerNum),
                    GameMaster = scriptVM.GameMaster,
                    UserId = userId,
                    CategoryId = scriptVM.Category
                };
                script_repo.Create(script);

                for(int i = 0; i < scriptVM.Characters.Count; i++)
                {
                    Characters character = new Characters
                    {
                        Intro = scriptVM.Characters[i].Intro,
                        Name = scriptVM.Characters[i].Name,
                        Image = scriptVM.Characters[i].Image,
                        ScriptId = script.Id
                    };
                    character_repo.Create(character);
                }

                for(int i = 0; i < scriptVM.Images.Count; i++)
                {
                    ScriptImages image = new ScriptImages
                    {
                        ScriptId = script.Id,
                        Image = scriptVM.Images[i].url,
                        OrderNumber = int.Parse(scriptVM.Images[i].orderNum)
                    };
                    scriptImg_repo.Create(image);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteScript(Guid Id)
        {
            Scripts script = script_repo.GetAll().FirstOrDefault(x => x.Id == Id);

            if(script != null)
            {
                IList<Characters> characters = character_repo.GetAll().Where(x => x.ScriptId == Id).ToList();
                foreach(var i in characters)
                {
                    character_repo.Delete(i);
                }
                IList<ScriptImages> images = scriptImg_repo.GetAll().Where(x => x.ScriptId == Id).ToList();
                foreach(var i in images)
                {
                    scriptImg_repo.Delete(i);
                }

                script_repo.Delete(script);
                return true;
            }else
            {
                return false;
            }
        }

        public ScriptViewModel GetScriptDetail(string name)
        {
            Scripts entity = script_repo.GetAll().FirstOrDefault(x => x.Name == name);
            if (entity != null)
            {
                ScriptViewModel scriptVM = new ScriptViewModel
                {
                    Difficulty = entity.Difficulty,
                    Id = entity.Id,
                    Intro = entity.Intro,
                    IsPlace = entity.IsPlace,
                    Name = entity.Name,
                    Owner = user_repo.GetAll().FirstOrDefault(x => x.Id == entity.UserId).Name,
                    PlayerNum = entity.PlayerNum.ToString(),
                    Price = entity.Price.ToString(),
                    Time = entity.Time.ToString(),
                    Tags = entity.Tags.Split('&').ToList(),
                    GameMaster = entity.GameMaster,
                    Characters = character_repo.GetAll().Where(x => x.ScriptId == entity.Id).Select(x => new Character
                    {
                        Image = x.Image,
                        Intro = x.Intro,
                        Name = x.Name
                    }).ToList()
                };

                return scriptVM;
            }
            else
            {
                return null;
            }
        }
    }
}
