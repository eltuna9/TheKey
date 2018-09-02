import React, {Component} from 'react';
import MainHeader from '../commons/mainHeader/mainHeader';
import SearchForm from './searchForm/searchForm';
import ResultSection from './resultSection/resultSection';
import './home.scss';
export class Home extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="container-fluid">
          <div className="row home__header">
            <MainHeader>The Key - Your SEO tool</MainHeader>
          </div>
        </div>
        <div className="container-fluid home__form-wrapper">
          <SearchForm />
        </div>
        <div className="container-fluid">
          <ResultSection />
        </div>
      </React.Fragment>
    );
  }
}
