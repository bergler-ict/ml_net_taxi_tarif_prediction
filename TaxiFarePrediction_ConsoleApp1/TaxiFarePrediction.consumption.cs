﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace TaxiFarePrediction_ConsoleApp1
{
    public partial class TaxiFarePrediction
    {
        /// <summary>
        /// model input class for TaxiFarePrediction.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"vendor_id")]
            public string Vendor_id { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"rate_code")]
            public float Rate_code { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"passenger_count")]
            public float Passenger_count { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"trip_distance")]
            public float Trip_distance { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"payment_type")]
            public string Payment_type { get; set; }

            [LoadColumn(6)]
            [ColumnName(@"fare_amount")]
            public float Fare_amount { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for TaxiFarePrediction.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"vendor_id")]
            public float[] Vendor_id { get; set; }

            [ColumnName(@"rate_code")]
            public float Rate_code { get; set; }

            [ColumnName(@"passenger_count")]
            public float Passenger_count { get; set; }

            [ColumnName(@"trip_distance")]
            public float Trip_distance { get; set; }

            [ColumnName(@"payment_type")]
            public float[] Payment_type { get; set; }

            [ColumnName(@"fare_amount")]
            public float Fare_amount { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("TaxiFarePrediction.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }
    }
}
