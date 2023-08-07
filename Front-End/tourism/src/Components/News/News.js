// News.js

import React, { useState, useEffect } from "react";
import "./News.css";

const News = (props) => {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    async function fetchNewsData() {
      try {
        const response = await fetch(
          `https://newsapi.org/v2/everything?q=Travel&apiKey=8d5363540d574bd08be82dd89c0aac07`
        );
        const data = await response.json();
        if (data.articles && data.articles.length > 0) {
          setArticles(data.articles);
        }
      } catch (error) {
        console.error("Error fetching news data:", error);
      }
    }

    fetchNewsData();
  }, [props.newsName]);

  return (
    <div className="news-container">
      {articles.length > 0 ? (
        articles.map((article, index) => (
          <div key={index} className="news-card">
            <img src={article.urlToImage} alt={article.title} />
            <div className="news-card-content">
              <h2 className="news-title">{article.title}</h2>
              <p className="news-description">{article.description}</p>
              <a href={article.url} className="read-more-link">
                Read more
              </a>
              <div className="news-tags">
                {article.tags &&
                  article.tags.map((tag, index) => (
                    <span key={index} className="news-tag">
                      #{tag}
                    </span>
                  ))}
              </div>
            </div>
          </div>
        ))
      ) : (
        <p>No news articles available.</p>
      )}
    </div>
  );
};

export default News;
