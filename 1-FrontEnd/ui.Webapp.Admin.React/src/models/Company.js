import Entity from './Entity'

export default class Company extends Entity {
    constructor(id='',companyName='',fantasyName='',corporateNumber='',createdBy='') {
      super()
      this.id = id;
      this.companyName = companyName;
      this.fantasyName= fantasyName;
      this.corporateNumber=corporateNumber;
      this.createdBy = createdBy;
    }
  }