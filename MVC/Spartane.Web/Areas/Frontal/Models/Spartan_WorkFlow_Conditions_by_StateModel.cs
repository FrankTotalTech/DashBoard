﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_Conditions_by_StateModel
    {
        [Required]
        public int Conditions_by_StateId { get; set; }
        public int? Phase { get; set; }
        public string PhaseName { get; set; }
        public int? State { get; set; }
        public string StateName { get; set; }
        public int? Condition_Operator { get; set; }
        public string Condition_OperatorDescription { get; set; }
        public int? Attribute { get; set; }
        public string AttributeLogical_Name { get; set; }
        public short? Condition { get; set; }
        public string ConditionDescription { get; set; }
        public short? Operator { get; set; }
        public string OperatorDescription { get; set; }
        public string Operator_Value { get; set; }
        [Range(0, 9999999999)]
        public short? Priority { get; set; }

    }
}

