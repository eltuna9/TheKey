import React, {Component} from 'react';
import Loader from 'react-loader-spinner';
import PropTypes from 'prop-types';
import {connect} from 'react-redux';
import AppeareanceBox from './appeareanceBox/appeareanceBox';
import './resultSection.scss';

class ResultSection extends Component {
  constructor(props) {
    super(props);
    this.state = {results: null};
  }
  render() {
    return (
      <div className="container">
        <div className="row result-section">
          {this.verifyPendingStatus()}
          {this.state.results &&
            this.state.results.length > 0 && (
              <React.Fragment>
                <h2 className="result-section__description">
                  We have found your url {this.state.results.length} times in the Google Search, in the following order.
                </h2>
                {this.state.results.map((result, index) => (
                  <AppeareanceBox key={index} linkTitle={result.LinkTitle} appearenceOrder={result.AppearenceOrder} />
                ))}
              </React.Fragment>
            )}
          {this.verifyEmptyResults()}
        </div>
      </div>
    );
  }

  verifyPendingStatus() {
    return (
      this.state.isPending && (
        <div className="result-section__loader">
          <h2 className="result-section__wait-message">
            We are performing the search and counting for you. Please wait =)
          </h2>
          <Loader className="result-section__spiner" type="Rings" color="#ffa100" height={120} width={120} />
        </div>
      )
    );
  }

  verifyEmptyResults() {
    return (
      this.state.results &&
      this.state.results.length === 0 && (
        <h2 className="result-section__description">
          We have not found your url in the Google Search =(, please try changing the keywords.
        </h2>
      )
    );
  }

  componentWillReceiveProps(newProps) {
    this.setState({
      results: newProps.searchResults,
      isPending: newProps.isSearchPending
    });
    console.log(newProps);
  }
}

const mapStateToProps = state => ({
  searchResults: state.search.searchResult,
  isSearchPending: state.search.isSearchPending
});

ResultSection.propTypes = {
  searchResults: PropTypes.object,
  isSearchPending: PropTypes.bool
};

export default connect(mapStateToProps)(ResultSection);
