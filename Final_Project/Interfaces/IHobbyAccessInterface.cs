using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Interfaces
{
    public interface IHobbyAccessInterface
    {
        List<Hobby> GetAllHobbyRecords();
        List<Hobby> GetHobbyRecordByID(int id);
        int? RemoveHobbyRecordById(int id);
        int? UpdateHobbyRecord(Hobby existingHobbyRecord);
        int? AddHobbyRecord(Hobby newHobbyRecord);
    }
}
