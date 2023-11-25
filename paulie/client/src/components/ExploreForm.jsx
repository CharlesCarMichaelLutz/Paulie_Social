const ExploreForm = ({
  getTweets,
  radioButtonValue,
  onRadioButtonChange,
  searchTerm,
  onInputChange,
}) => {
  return (
    <form onSubmit={getTweets}>
      <section className="group--radio">
        <div className="radio">
          <div className="btn-group btn-group-toggle" data-toggle="buttons">
            <label
              className={`btn btn-primary ${
                radioButtonValue === "username" ? "active" : ""
              } green-button`}
              htmlFor="button1"
            >
              <input
                type="radio"
                value="username"
                id="button1"
                className="hidden-radio"
                checked={radioButtonValue === "username"}
                onChange={onRadioButtonChange}
              />
              Username
            </label>
            <label
              className={`btn btn-primary ${
                radioButtonValue === "content" ? "active" : ""
              } green-button`}
              htmlFor="button2"
            >
              <input
                type="radio"
                value="content"
                id="button2"
                className="hidden-radio"
                checked={radioButtonValue === "content"}
                onChange={onRadioButtonChange}
              />
              Content
            </label>
          </div>
        </div>
      </section>

      <input
        placeholder="search...."
        type="text"
        className="search--bar"
        value={searchTerm}
        onChange={onInputChange}
      />
      <button type="submit" className="submit--button">
        Get Tweets
      </button>
    </form>
  );
};

export default ExploreForm;
