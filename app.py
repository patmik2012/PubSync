from scholarly import scholarly
from flask import Flask

app = Flask(__name__)

@app.route("/api/<name>")
def parse_request(name):
    return fetch_author_data(name)

def fetch_author_data(name):
    search_query = scholarly.search_author(name)
    d = scholarly.fill(next(search_query))

    publications = []

    for i in d.get('publications'):
        publication = {}
        publication['title'] = i.get('bib').get('title')
        publication['pub_year'] = i.get('bib').get('pub_year')
        publication['num_citations'] = i.get('num_citations')
        publications.append(publication)

    data = {}

    data['name'] = d.get('name')
    data['affiliation'] = d.get('affiliation')
    data['email_domain'] = d.get('email_domain')
    data['interests'] = d.get('interests')
    data['citedby'] = d.get('citedby')
    data['number_of_publications'] = len(publications)
    data['publications'] = publications
    return data

if __name__ == "__main__":
    app.run()