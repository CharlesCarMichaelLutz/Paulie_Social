import React from "react";
import bigParrot from "../static/bigparrot.jpg";
//import bigParrot from "../parrot2.JPG";
import { Helmet } from "react-helmet-async";

const Home = () => {
  return (
    <>
      <div class="container">
        <Helmet>
          <title>Paulie Social - Home</title>
        </Helmet>
        <header className="home--header">
          <h1>Welcome to Paulie Social!</h1>
        </header>

        <main className="main--home">
          <p>
            Inspired by the movie{" "}
            <a href="https://www.imdb.com/title/tt0125454/?ref_=nv_sr_srsg_0">
              Paulie(1998){" "}
            </a>
            , and creating my birdlike social application the name "Paulie
            Social" fits just right. On this site you can navigate to the
            Explore page, and find tweets from whoever you like with searching
            by content or username. Also clicking on the VIP page will allow you
            to select a User and view a random tweet of theirs. Enjoy the
            experience of Paulie Social.
          </p>

          <img src={bigParrot} className="main--image" alt="app logo image" />
        </main>
      </div>
    </>
  );
};

export default Home;
