from scholarly import scholarly
from flask import Flask

app = Flask(__name__)

@app.route("/api/quick/<name>")
def get_auth_quick(name):
    try:
        return quick_fetch_author(name)
    except StopIteration:
        return failed_fetch('Author does not have a Google Scholar profile')

@app.route("/api/detailed/<name>")
def get_auth_detailed(name):
    try:
        return detailed_fetch_author(name)
    except StopIteration:
        return failed_fetch('Author does not have a Google Scholar profile')

@app.route('/api/quick/<name>/<id>')
def get_pub(name, id):
    try:
        return fetch_publication_from_id(name, int(id))
    except Exception as exc:
        return failed_fetch(str(exc))

def quick_fetch_author(name):
    search_query = scholarly.search_author(name)
    author = scholarly.fill(next(search_query), sections=['publications', 'coauthors'])
    iterator = 0

    data = {}
    publications = []
    coauthors = []

    for auth in author['coauthors']:
        coauthors.append(auth['name'])

    for pub in author['publications']:
        pub_info = {}
        make_attribute(pub_info, 'title', pub, 'bib')
        make_attribute(pub_info, 'num_citations', pub, 'plain')
        make_attribute(pub_info, 'pub_year', pub, 'bib')
        pub_info['_id'] = iterator
        iterator += 1
        publications.append(pub_info)

    
    make_attribute(data, 'name', author, 'plain')
    make_attribute(data, 'coauthors', coauthors, 'obj')
    make_attribute(data, 'affiliation', author, 'plain')
    make_attribute(data, 'email_domain', author, 'plain')
    make_attribute(data, 'interests', author, 'plain')
    make_attribute(data, 'citedby', author, 'plain')
    make_attribute(data, 'number_of_publications', len(publications), 'obj')
    make_attribute(data, 'publications', publications, 'obj')
    return data

def detailed_fetch_author(name):
    search_query = scholarly.search_author(name)
    author = scholarly.fill(next(search_query), sections=['publications', 'coauthors'])

    iterator = 0
    data = {}
    publications = []
    coauthors = []

    for auth in author['coauthors']:
        coauthor = {}
        make_attribute(coauthor, 'affiliation', auth, 'plain')
        make_attribute(coauthor, 'affiliation', auth, 'plain')
        coauthors.append(auth['name'])

    for pub in author['publications']:
        scholarly.fill(pub)
        pub_info = {}
        make_attribute(pub_info, 'title', pub, 'bib')
        make_attribute(pub_info, 'author', pub, 'bib')
        make_attribute(pub_info, 'pub_year', pub, 'bib')
        make_attribute(pub_info, 'abstract', pub, 'bib')
        make_attribute(pub_info, 'journal', pub, 'bib')
        make_attribute(pub_info, 'number', pub, 'bib')
        make_attribute(pub_info, 'pages', pub, 'bib')
        make_attribute(pub_info, 'publisher', pub, 'bib')
        make_attribute(pub_info, 'volume', pub, 'bib')
        make_attribute(pub_info, 'num_citations', pub, 'plain')
        pub_info['_id'] = iterator
        iterator += 1
        publications.append(pub_info)
    
    make_attribute(data, 'name', author, 'plain')
    make_attribute(data, 'coauthors', coauthors, 'obj')
    make_attribute(data, 'affiliation', author, 'plain')
    make_attribute(data, 'email_domain', author, 'plain')
    make_attribute(data, 'interests', author, 'plain')
    make_attribute(data, 'citedby', author, 'plain')
    make_attribute(data, 'number_of_publications', len(publications), 'obj')
    make_attribute(data, 'publications', publications, 'obj')
    return data

def fetch_publication_from_id(name, id):
    search_query = scholarly.search_author(name)
    pub = scholarly.fill(next(search_query), sections=['publications'])
    scholarly.fill(pub['publications'][id])
    result = pub['publications'][id]
    data = {}
    make_attribute(data, 'title', result, 'bib')
    make_attribute(data, 'author', result, 'bib')
    make_attribute(data, 'pub_year', result, 'bib')
    make_attribute(data, 'abstract', result, 'bib')
    make_attribute(data, 'journal', result, 'bib')
    make_attribute(data, 'number', result, 'bib')
    make_attribute(data, 'pages', result, 'bib')
    make_attribute(data, 'publisher', result, 'bib')
    make_attribute(data, 'volume', result, 'bib')
    make_attribute(data, 'num_citations', result, 'plain')
    return data

def make_attribute(obj, attribute_name, value, istype):
    try:
        if istype == 'bib':
            obj[attribute_name] = value['bib'][attribute_name]
        elif istype == 'plain':
            obj[attribute_name] = value[attribute_name]
        elif istype == 'obj':
            obj[attribute_name] = value
    except KeyError:
        obj[attribute_name] = None


def failed_fetch(exc):
    error = {}
    error['_message'] = 'An exception has occurred'
    error['exception'] = exc
    return error

if __name__ == "__main__":
    app.run()
