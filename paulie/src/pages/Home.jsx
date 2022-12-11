import React from 'react';
import image from '../bigparrot.jpg';
const Home = () => {

  return (
    <body>
      <header>
      Paulie Social!
      </header>

      <main>

        <span>
          Lorem ipsum dolor sit amet. Et repellat 
          obcaecati in molestiae illo ut architecto 
          eius aut doloribus sint. Non explicabo dolorem 
          id quia adipisci ea quia quae quo quia doloribus
          et quibusdam molestiae non laborum eveniet. Est
          fuga dolores qui dolores vitae aut corporis tempora 
          cum nihil quae sed corporis eveniet.         
        </span>

        <span>
          <img src={image} height={400} width={400} />
        </span>
      </main>

    </body>
  )
}

export default Home