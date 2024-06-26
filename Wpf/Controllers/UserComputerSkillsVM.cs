﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class UserComputerSkillsVM
    {
        Core db = new Core();
        /// <summary>
        /// Метод для добавления компьютерных навыков
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="skill">Компьютерные навыки</param>
        public void AddNewComputerSkills(int iduser, string skill)
        {
                UserComputerSkills newUser = new UserComputerSkills()
                {
                    IdSearcher = iduser,
                    ComputerSkill = skill
                };
                db.context.UserComputerSkills.Add(newUser);
                db.context.SaveChanges();
            }
        /// <summary>
        /// Метод для изменения компьютерных навыков
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="skill">Компьютерные навыки</param>
        public void EditComputerSkills(int iduser, string skill)
        {
            var objComputerSkills = db.context.UserComputerSkills.Where(x => x.IdSearcher == iduser).SingleOrDefault();
            if (objComputerSkills != null)
            {
                objComputerSkills.ComputerSkill = skill;
            }
            else
            {
                UserComputerSkills newComputerSkill = new UserComputerSkills()
                {
                    IdSearcher = iduser,
                    ComputerSkill = skill
                };
                db.context.UserComputerSkills.Add(newComputerSkill);
            }
            db.context.SaveChanges();
        }
    }


    }
