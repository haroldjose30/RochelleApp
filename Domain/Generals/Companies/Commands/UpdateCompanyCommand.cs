﻿using System;
using Domain.Generals.Companies.Validations;

namespace Domain.Generals.Companies.Commands
{
    public class UpdateCompanyCommand : CompanyCommand
    {
        public UpdateCompanyCommand(string id,string modifiedBy, string companyName, string fantasyName, string corporateNumber)
        {
            this.Id = id;
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.CorporateNumber = corporateNumber;
            this.By = modifiedBy;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCompanyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
