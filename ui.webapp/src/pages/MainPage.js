import React from 'react';
import Page from '../components/Page';






class MainPage extends React.Component {
  componentDidMount() {

  }

  render() {

    return (
      <Page
        className="Main"
        title="Menu Principal"
        >
        Utilize o menu lateral para navegar entre as páginas
      </Page>
    );
  }
}
export default MainPage;
