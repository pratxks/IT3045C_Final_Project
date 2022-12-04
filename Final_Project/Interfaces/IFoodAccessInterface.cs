using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Interfaces
{
    //Pratik Chaudhari
    public interface IFoodAccessInterface
    {
        List<Food> GetAllFoodRecords();
        List<Food> GetFoodRecordByID(int id);
        int? RemoveFoodRecordById(int id);
        int? UpdateFoodRecord(Food existingFoodRecord);
        int? AddFoodRecord(Food newFoodRecord);
    }
}
