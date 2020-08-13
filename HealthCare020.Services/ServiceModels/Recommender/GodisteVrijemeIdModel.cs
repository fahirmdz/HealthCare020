using System;
using Microsoft.ML.Data;

namespace HealthCare020.Services.ServiceModels.Recommender
{
    public class GodisteVrijemeIdModel
    {
        [KeyType(2000)]
        public uint Godiste { get; set; }

        [KeyType(2000)]
        public uint VrijemeUid { get; set; }

        public float Label { get; set; }
    }
}