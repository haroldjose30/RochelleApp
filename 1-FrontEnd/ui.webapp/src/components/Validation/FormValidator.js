//ref https://medium.com/code-monkey/client-side-form-validation-in-react-40e367de47ba
//ref https://github.com/mikeries/dive-log-client/tree/master/src

//validations functions
//https://github.com/chriso/validator.js

import validator from 'validator';


class FormValidator {
  constructor(validations) {
    this.validations = validations;
  }

  validate = state => {
    let validation = this.reset();
    this.validations.forEach(v => {
      if (!validation[v.field].isInvalid) {
        const args = v.args || [];
        const validation_method = 
              typeof v.method === 'string' ?
              validator[v.method] : 
              v.method
        
        if(state.item[v.field] === undefined) {
          validation[v.field] = this.getTemplate(false,true,v.message)
          validation.isValid = false;
        }
        else {
          const value = state.item[v.field];
          if(validation_method(value, ...args, state) !== v.validWhen) {
            validation[v.field] = this.getTemplate(false,true,v.message)
            validation.isValid = false;
          }
          else {
            validation[v.field] = this.getTemplate(true,false,'')
          }
        }
           

      }
    });

    return validation;
  }

  validateSingle = (field,value) => {

    let validation = this.resetSingle(field);
   

    this.validations.forEach(v => {
      if (v.field === field) {

        if (!validation[v.field].isInvalid) {
          const args = v.args || [];
          const validation_method = 
                typeof v.method === 'string' ?
                validator[v.method] : 
                v.method

          if(value === undefined) {
            validation[v.field] = this.getTemplate(false,true,v.message)
            validation.isValid = false;
          }
          else
            if(validation_method(value.toString(), ...args, value) !== v.validWhen) {
              validation[v.field] = this.getTemplate(false,true,v.message)
              validation.isValid = false;
            }
            else 
              validation[v.field] = this.getTemplate(true,false,'')
        }

      }
      
    });

    return validation;
  }


  reset = () => {
    const validation = {}

    this.validations.forEach(v => {
      validation[v.field] = this.getTemplate(false,false,'')
    });
   
    return { isValid: true, ...validation };
  }

  resetSingle = (field) => {
    let validation = {}
      validation[field] =  this.getTemplate(false,false,'')
    return { ...validation };
  }

  getTemplate = (isValid,isInvalid,message) => {
    return {isValid:isValid, isInvalid: isInvalid, message: message} 
  }



}

export default FormValidator;