import React from 'react';
import CompanyForm from './CompanyForm';
import FormValidator from '../../components/Validation/FormValidator';
import update from 'immutability-helper';
import * as rules from '../../components/Validation/rules';
import Company from '../../models/Company';

const CompanyPageValidations = [
  { field: 'companyName', ...rules.isEmpty},
  { field: 'fantasyName', ...rules.isEmpty},
  { field: 'corporateNumber', ...rules.isEmpty},
  { field: 'corporateNumber', ...rules.isNumeric},
]

class CompanyFormPage extends React.Component {
    constructor(props) {
        super(props);
        this.validator = new FormValidator(CompanyPageValidations);

        const item =  (this.props.location.item===undefined ? new Company() : this.props.location.item)

        this.state = {
          validations: this.validator.reset(),
          item: item,
          modalState:false
        };
        
      }

      onHandleInputChange = event => {
          const {name, value} = event.target
          const validationSingle = this.validator.validateSingle(name,value);
          const newState = update(this.state,{
                                                validations: {$merge: validationSingle},
                                                item:{[name]: {$set: value}}
                                              });
          this.setState(newState);
        }

        onHandleSubmit = event => {
          event.preventDefault();
          const validations = this.validator.validate(this.state);
          const newState = update(this.state, {$merge: {validations: validations}});
          this.setState(newState);
        
          if (validations.isValid) {
            //call submit functions      
          }
        }

        

    onModalStateChange = () => {
      this.setState({ modalState:!this.state.modalState})
    };

    onHandleBack = event => {
        this.props.history.push('/company');
      };

    onHandleDelete = event => {
      this.onModalStateChange()
    };

    onModalClick = event => {
      console.log(event.target.name);
      this.onModalStateChange()
    };

    
      
  render() {
    
    return (
        <CompanyForm
            cardHeader={''}
            onHandleSubmit={this.onHandleSubmit}
            onHandleBack={this.onHandleBack}
            onHandleDelete={this.onHandleDelete}
            onHandleInputChange={this.onHandleInputChange}
            validations={this.state.validations}
            item={this.state.item}
            modalState={this.state.modalState}
            onModalStateChange={this.onModalStateChange}
            onModalClick={this.onModalClick}
        />
    );
  }
}

export default CompanyFormPage;