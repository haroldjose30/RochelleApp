import React from 'react';
import CompanyList from './CompanyList';
import Company from '../../models/Company';
import GenericRepository from './GenericRepository';


class CompanyFormPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {list: [],
                      loading:true}
    }

    changeLoading = loading =>  this.setState({loading:loading})

    componentDidMount() {
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

    onHandleNewClick = () => {
        this.props.history.push({
            pathname: '/company/form',
            item: new Company(),
          })
      };

    onHandleEditClick = item => {
        this.props.history.push({
            pathname: '/company/form',
            item: item
          })
      };
      
  render() {
    return (
        <CompanyList
            onHandleNewClick={this.onHandleNewClick}
            onHandleEditClick={this.onHandleEditClick}
            list={this.state.list}
            alertMessage={this.state.alertMessage}
            loading={this.state.loading}
        />
    );
  }
}

export default CompanyFormPage;