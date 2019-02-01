import React from 'react';
import CompanyForm from './CompanyForm';
import FormValidator from '../../components/Validation/FormValidator';
import update from 'immutability-helper';
import * as rules from '../../components/Validation/rules';
import Company from '../../models/Company';
import GenericRepository from './GenericRepository';

const CompanyPageValidations = [
  { field: 'companyName', ...rules.isEmpty},
  { field: 'fantasyName', ...rules.isEmpty},
  { field: 'corporateNumber', ...rules.isEmpty},
  { field: 'corporateNumber', ...rules.isNumeric},
]

const resource = "Companies"
class CompanyFormPage extends React.Component {
    constructor(props) {
        super(props);
        this.validator = new FormValidator(CompanyPageValidations);

        const item =  (this.props.location.item===undefined ? new Company() : this.props.location.item)
        const insert =  (this.props.location.insert===undefined ? true : this.props.location.insert)

        this.state = this.getDefaultState(item,insert)
        
      }

      getDefaultState = (item,insert) => {
        return {
          validations: this.validator.reset(),
          item: item,
          modalState:false,
          insert:insert,
          loading:false,
        }
    };

      changeLoading = loading =>  this.setState({loading:loading})

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
          console.log('onHandleSubmit');


          const validations = this.validator.validate(this.state);
          const newState = update(this.state, {$merge: {validations: validations}});
          this.setState(newState);
        
          if (validations.isValid) {
            console.log('this.state.insert');
            console.log(this.state.insert);
            if (this.state.insert){
                this.changeLoading(true);
                var companyRepository = new GenericRepository(resource)
                companyRepository.post(this.state.item)
                    .then(company => {
                                console.log('company');
                                console.log(company);
                                this.state.item = new Company()
                                this.changeLoading(false);
                    })
                    .catch(errors => {
                        this.setState({
                            alertMessage:errors.message
                        })

                        this.changeLoading(false);
                    });

            }else{
                  this.changeLoading(true);
                  var companyRepository = new GenericRepository('Companies')
                  companyRepository.get()
                      .then(list => {
                              if (list !== undefined)
                                  this.setState({
                                      list:list,
                                      alertMessage:''
                                  })
                              
                                  this.changeLoading(false);
                      })
                      .catch(errors => {
                          this.setState({
                              alertMessage:errors.message
                          })

                          this.changeLoading(false);
                      });
            }

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