import React from 'react';
import Page from '../components/Page';






class MainPage extends React.Component {
  componentDidMount() {
    // this is needed, because InfiniteCalendar forces window scroll
    window.scrollTo(0, 0);
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
