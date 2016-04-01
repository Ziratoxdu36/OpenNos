﻿/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using AutoMapper;
using OpenNos.DAL.EF.MySQL.DB;
using OpenNos.DAL.EF.MySQL.Helpers;
using OpenNos.DAL.Interface;
using OpenNos.Data;
using System.Collections.Generic;
using System.Linq;

namespace OpenNos.DAL.EF.MySQL
{
    public class SkillShopDAO : ISkillShopDAO
    {
        #region Methods

        public SkillShopDTO Insert(SkillShopDTO skillshop)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                SkillShop entity = Mapper.Map<SkillShop>(skillshop);
                context.skillshop.Add(entity);
                context.SaveChanges();
                return Mapper.Map<SkillShopDTO>(entity);
            }
        }

        public IEnumerable<SkillShopDTO> LoadByNpc(int npcId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (SkillShop skillshop in context.skillshop.Where(s => s.MapNpcId.Equals(npcId)))
                {
                    yield return Mapper.Map<SkillShopDTO>(skillshop);
                }
            }
        }

        #endregion
    }
}