import React, {Component} from 'react';
import {Col, Grid, Row} from 'react-bootstrap';
import MainHeader from '../commons/mainHeader/mainHeader';
import SearchForm from './searchForm/searchForm';

export class Home extends Component {
  displayName = Home.name;

  render() {
    return (
      <Grid fluid className="">
        <Row className="home__header">
          <MainHeader text="The Key - Your SEO tool." />
        </Row>
        <Row className="home__form-wrapper">
          <SearchForm />
        </Row>
        <Row className="home__form-wrapper">
          <ResultSection />
        </Row>
      </Grid>
    );
  }
}
