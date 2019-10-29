import React from 'react';
import CompanyForm from './CompanyForm';
import FormValidator from '../../components/Validation/FormValidator';
import update from 'immutability-helper';
import * as rules from '../../components/Validation/rules';
import Company from '../../models/Company';
import GenericRepository from './GenericRepository';

//define form validations to Company model
const CompanyPageValidations = [
  { field: 'companyName', ...rules.isEmpty },
  { field: 'fantasyName', ...rules.isEmpty },
  { field: 'corporateNumber', ...rules.isEmpty },
  { field: 'corporateNumber', ...rules.isNumeric },
]
//define resource name to Api
const resource = "Companies"
class CompanyFormPage extends React.Component {
  constructor(props) {
    super(props);

    this.validator = new FormValidator(CompanyPageValidations);

    const item = (this.props.location.item === undefined ? new Company() : this.props.location.item)
    const insert = (this.props.location.insert === undefined ? true : this.props.location.insert)

    //todo:implementar controle de usuario
    item.createdBy = 'debug';
    item.modifiedBy = 'debug';

    this.state = this.getDefaultState(item, insert)

  }

  getDefaultState = (item, insert) => {
    return {
      validations: this.validator.reset(),
      item: item,
      modalState: false,
      insert: insert,
      loading: false,
    }
  };

  changeLoading = loading => this.setState({ loading: loading })

  onHandleInputChange = event => {
    const { name, value } = event.target
    const validationSingle = this.validator.validateSingle(name, value);
    const newState = update(this.state, {
      validations: { $merge: validationSingle },
      item: { [name]: { $set: value } }
    });
    this.setState(newState);
  }

  /**  
   * onHandleSubmit
  */
  onHandleSubmit = event => {
    event.preventDefault();

    //do data validations
    const validations = this.validator.validate(this.state);

    //get new state for validations
    const newState = update(this.state, { $merge: { validations: validations } });
    this.setState(newState);

    //if validations is valid execute POST or Show Erros message
    if (validations.isValid) {

      //if form state inseting new data
      if (this.state.insert) {
        //Show loading component
        this.changeLoading(true);

        //create a company repository
        var companyRepository = new GenericRepository(resource)

        //execute post method on backend
        companyRepository.post(this.state.item)
          .then(company => {
            //create new Company model
            this.state.item = new Company();

            //hide loading component
            this.changeLoading(false);
          })
          //if an errors occours
          .catch(errors => {
            //show messa error
            this.setState({
              alertMessage: errors.message
            })

            console.log("state:", this.state)


            this.changeLoading(false);
          });
      }  //if (this.state.insert) {
      else {
        //if updating data
        //Show loading component
        this.changeLoading(true);

        //create a company repository
        var companyRepository = new GenericRepository(resource)

        //execute post method on backend
        companyRepository.put(this.state.item)
          .then(company => {
            //create new Company model
            this.state.item = new Company();

            //hide loading component
            this.changeLoading(false);
          })
          //if an errors occours
          .catch(errors => {
            //show messa error
            this.setState({
              alertMessage: errors.message
            })

            console.log("state:", this.state)


            this.changeLoading(false);
          });

      }

    }
  }



  onModalStateChange = () => {
    this.setState({ modalState: !this.state.modalState })
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
        alertMessage={this.state.alertMessage}
      />
    );
  }
}

export default CompanyFormPage;