//ref https://github.com/chriso/validator.js
//ref https://github.com/chriso/validator.js/blob/master/test/validators.js

const defaultLocale = 'pt-BR' 

/**
 * check if the string has a length of zero.
 */
export const isEmpty = {method: 'isEmpty', args: [{ ignore_whitespace:true }], validWhen: false, message: 'Campo obrigatório!'}

/**
 * check if the string contains only numbers.
options is an object which defaults to {no_symbols: false}. If no_symbols is true, the validator will reject numeric strings that feature a symbol (e.g. +, -, or .).
 */
export const isNumeric = {method: 'isNumeric', validWhen: true, message: 'Informe apenas numeros!'}

/**
 * check if the string is an email.
 */
export const isEmail = {method: 'isEmail', validWhen: true, message: 'E-mail inválido!'}

/**
 * check if the string is an URL.
 */
export const isURL = {method: 'isURL', validWhen: true, message: 'URL inválida!'}

/**
 * check if the string is a MAC address.
 */
export const isMACAddress = {method: 'isMACAddress', validWhen: true, message: 'MAC Address inválida!'}

/**
 * check if the string is an IP (version 4 or 6).
 */
export const isIP = {method: 'isIP', validWhen: true, message: 'Endereço de Ip inválido!'}


/**
 * check if the string contains only letters (a-zA-Z).
 */
export const isAlpha = {method: 'isAlpha', validWhen: true, message: 'Informe apenas letras!'}

/**
 * check if the string contains only letters and numbers.
 */
export const isAlphanumeric = {method: 'isAlphanumeric', validWhen: true, message: 'Informe apenas letras e números!'}

/**
 * check if the string is a valid port number.
 */
export const isPort = {method: 'isPort', validWhen: true, message: 'Porta Inválida!'}

/**
 * check if the string represents a decimal number, such as 0.1, .3, 1.1, 1.00003, 4.0, etc.

options is an object which defaults to {force_decimal: false, decimal_digits: '1,', locale: 'en-US'}
Note: decimal_digits is given as a range like '1,3', a specific value like '3' or min like '1,'.
 */
export const isDecimal = {method: 'isDecimal', args: [{ locale: defaultLocale }], validWhen: true, message: 'Valor incorreto!'}

/**
 * check if the string is lowercase.
 */
export const isLowercase = {method: 'isLowercase', validWhen: true, message: 'Informe apenas em minúsculo!'}

/**
 * check if the string is uppercase.
 */
export const isUppercase = {method: 'isUppercase', validWhen: true, message: 'Informe apenas em maiúsculo!'}

/**
 * check if the string is an integer.
 */
export const isInt = {method: 'isInt', validWhen: true, message: 'Informe valores inteiros!'}

/**
 * check if the string is an integer. with minimal parameter
 * @param {number} min be >= min parameter
 */
export const isIntMin = min => {
   return {method: 'isInt', args: [{min: min,}],validWhen: true, message: `Valor deve ser maior ou igual a ${min} !`}
}

/**
 * check if the string is an integer. with minimal parameter
 * @param {number} max be <= max parameter
 */
export const isIntMax = max => {
    return {method: 'isInt', args: [{max: max,}],validWhen: true, message: `Valor deve ser menor ou igual a ${max} !`}
 }

 /**
  *  check if the string is an integer. with minimal and maximal parameter
  * @param {number} min be >= min parameter
  * @param {number} max be <= max parameter
  */
 export const isIntMinMax = (min,max) => {
    return {method: 'isInt', args: [{min: min,max: max,}],validWhen: true, message: `Valor deve ser entre ${min} e ${max} !`}
 }

 /**
  * check if the string is a float.
  */
export const isFloat = {method: 'isFloat', validWhen: true, message: 'Valor incorreto!'}

 /**
  *  check if the string is a float.
  * @param {number} min be >= min parameter
  */
export const isFloatMin = min => {
    return {method: 'isFloat', args: [{min: min,}],validWhen: true, message: `Valor deve ser maior ou igual a ${min} !`}
 }
 
  /**
  *  check if the string is a float.
  * @param {number} max be <= max parameter
  */
 export const isFloatMax = max => {
     return {method: 'isFloat', args: [{max: max,}],validWhen: true, message: `Valor deve ser menor ou igual a ${max} !`}
  }
 
   /**
  *  check if the string is a float.
  * @param {number} min be >= min parameter
  * @param {number} max be <= max parameter
  */
  export const isFloatMinMax = (min,max) => {
     return {method: 'isFloat', args: [{min: min,max: max,}],validWhen: true, message: `Valor deve ser entre ${min} e ${max} !`}
  }

  /**
   * check if the string is a hexadecimal color.
   */
  export const isHexColor = {method: 'isHexColor', validWhen: true, message: 'Cor inválida!'}


/**
 * check if the string contains the seed.
 * @param {string} seed string fot compare
 */
export const contains = (seed) => {
    return {method: 'contains', args: [seed],validWhen: true, message: `Deve conter ${seed}!`}
 }


 /**
  * check if the string's length falls in a range.
  * @param {number} min be >= min parameter
  */
 export const isLengthMin = (min) => {
    return {method: 'isLength', args: [{min: min,}],validWhen: true, message: `Deve ter no minimo ${min} caracteres!`}
 }

  /**
  * check if the string's length falls in a range.
  * @param {number} max be <= max parameter
  */

 export const isLengthMax = (max) => {
    return {method: 'isLength', args: [{max: max,}],validWhen: true, message: `Deve no máximo ${max} caracteres!`}
 }

  /**
  * check if the string's length falls in a range.
  * @param {number} min be >= min parameter
  * @param {number} max be <= max parameter
  */

 export const isLengthMinMax = (min,max) => {
    return {method: 'isLength', args: [{min: min,max: max,}],validWhen: true, message: `Deve ter entre ${min} e ${max} caracteres!`}
 }

/**
 * check if the string is a UUID (version 3, 4 or 5).
 */
 export const isUUID = {method: 'isUUID', validWhen: true, message: 'Cor inválida!'}

/**
 * check if the string is in a array of allowed values.
 * @param {*} values allowed values array ex: ['foo','bar']
 */
 export const isIn = (values) => {
    return {method: 'isIn',  args: [values], validWhen: true, message: `Deve conter os valores ${values}!`}
 }

 /**
  * check if the string matches the comparison.
  * @param {string} comparison string for comparison
  */
 export const equals = (comparison) => {
    return {method: 'equals',  args: [comparison], validWhen: true, message: `Deve ser igual a ${comparison}!`}
 }
 

 /**
  * check if the string is a date that's after the specified date (defaults to now).
  */
 export const isAfter = {method: 'isAfter', validWhen: true, message: `Data deve ser maior que hoje!`}


 /**
  * check if the string is a date that's after the specified date (defaults to now).
  * @param {string} date 
  */
 export const isAfterThen = (date) => {
    return {method: 'isAfter',  args: [date], validWhen: true, message: `Data deve ser depois de ${date}!`}
 }


  /**
  * check if the string is a date that's before the specified date.
  */
 export const isBefore = {method: 'isBefore', validWhen: true, message: `Data deve ser antes de hoje!`}


  /**
  * check if the string is a date that's before the specified date.
  * @param {string} date 
  */
 export const isBeforeThen = (date) => {
    return {method: 'isBefore',  args: [date], validWhen: true, message: `Data deve ser antes de ${date}!`}
 }


/**
  * check if the string is a credit card.
  */
 export const isCreditCard = {method: 'isCreditCard', validWhen: true, message: `Cartão de crédito inválido!`}


 
 /**
  *  check if the string is valid JSON (note: uses JSON.parse).
  */
 export const isJSON = {method: 'isJSON', validWhen: true, message: `Json inválido!`}


  /**
  *  check if the string is valid JWT token.
  */
 export const isJWT = {method: 'isJWT', validWhen: true, message: `JWT Inválido!!`}


  /**
  *  check if the string is a valid latitude-longitude coordinate in the format lat,long or lat, long.
  */
 export const isLatLong = {method: 'isLatLong', validWhen: true, message: `Latitude/Longitudo inválida!`}


  /**
  *  check if a string is base64 encoded.
  */
 export const isBase64 = {method: 'isBase64', validWhen: true, message: `Base64 inválida!!`}


  /**
  *  check if the string is a mobile phone number,
  */
 export const isMobilePhone = {method: 'isMobilePhone',args: [{ locale: defaultLocale }],  validWhen: true, message: `Celular inválido!`}

/**
  *  check if the string is a valid currency amount.
  */
 export const isCurrency = {method: 'isCurrency',args: [{ locale: defaultLocale }],  validWhen: true, message: `Celular inválido!`}

 
let isMyCustonRule = value => {
    //do something with value e return status validade
    return false;
}

export const isCuston = {method: isMyCustonRule, validWhen: true, message: 'erro customizado'}


