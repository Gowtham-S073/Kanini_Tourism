import React from "react";
import styled from "styled-components";
import avatarImage from "../../Assests/avatarImage.jpg";
export default function Testimonials() {
  return (
    <Section id="testimonials">
      <div className="title">
        <h2>Happy Customers``</h2>
      </div>
      <div className="testimonials">
        <div className="testimonial">
          <p>
          
I am back from the Unique Swiss Paris Mode. I can describe it in one line - I think I died and went to heaven and now I am back :) The whole trip was a Karmic Connection and I felt I was in a dream


          </p>
          <div className="info">
            <img src={avatarImage} alt="123" />
            <div className="details">
              <h4>- ROOPA SOMASUNDARAN</h4>
              <span></span>
            </div>
          </div>
        </div>
        <div className="testimonial">
          <p>
          Many Thanks for your effort with me. Be sure for my coming trips it will be with you as i was very pleased with your professionalization. Once again thank you personally and thanks TripBooking.
          </p>
          <div className="info">
            <img src={avatarImage} alt="23456" />
            <div className="details">
              <h4>- PARAG RAMCHANDRA PHADKE</h4>
              <span></span>
            </div>
          </div>
        </div>
        <div className="testimonial">
          <p>
          The telephone Customer service team was very supportive. Special mention about Puneet Sharma, who was very helpful and patient in handling all queries and all bookings were done professionally by him.


          </p>
          <div className="info">
            <img src={avatarImage} alt="6789" />
            <div className="details">
              <h4>- UDAY KUMAR SARMA</h4>
              <span>CEO - Shashaan Web Solutions</span>
            </div>
          </div>
        </div>
      </div>
    </Section>
  );
}

const Section = styled.section`
  margin: 5rem 0;
  .title {
    text-align: center;
    margin-bottom: 2rem;
  }
  .testimonials {
    display: flex;
    justify-content: center;
    margin: 0 2rem;
    gap: 2rem;
    .testimonial {
      background-color: aliceblue;
      padding: 2rem;
      border-radius: 0.5rem;
      box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
      transition: 0.3s ease-in-out;
      &:hover {
        transform: translateX(0.4rem) translateY(-1rem);
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
      }
      .info {
        display: flex;
        justify-content: center;
        gap: 1rem;
        align-items: center;
        margin-top: 1rem;
        img {
          border-radius: 3rem;
          height: 3rem;
        }
        .details {
          span {
            font-size: 0.9rem;
          }
        }
      }
    }
  }
  @media screen and (min-width: 280px) and (max-width: 768px) {
    .testimonials {
      flex-direction: column;
      margin: 0;
      .testimonial {
        justify-content: center;
        .info {
          flex-direction: column;
          justify-content: center;
        }
      }
    }
  }
`;
