class PhoneBook:
    def __init__(self):
        self.contacts = {}  # Основной справочник {номер: {name, group, tags}}
        self.groups = {}  # Словарь групп {group_name: [numbers]}
        self.tags = {}  # Словарь меток {tag_name: [numbers]}

    def add_contact(self, number, name, group=None):
        if number in self.contacts:
            self.contacts[number]['name'] = name
        else:
            self.contacts[number] = {'name': name, 'group': group, 'tags': set()}
        if group:
            if group not in self.groups:
                self.groups[group] = []
            if number not in self.groups[group]:
                self.groups[group].append(number)

    def delete_contact(self, number):
        if number in self.contacts:
            group = self.contacts[number]['group']
            if group and number in self.groups.get(group, []):
                self.groups[group].remove(number)
            for tag in self.contacts[number]['tags']:
                if number in self.tags[tag]:
                    self.tags[tag].remove(number)
            del self.contacts[number]

    def find_contact(self, number):
        return self.contacts.get(number, {}).get('name', 'not found')

    def add_tag(self, number, tag_name):
        if number in self.contacts:
            self.contacts[number]['tags'].add(tag_name)
            if tag_name not in self.tags:
                self.tags[tag_name] = []
            if number not in self.tags[tag_name]:
                self.tags[tag_name].append(number)

    def find_by_group(self, group_name):
        if group_name in self.groups:
            return [self.contacts[number]['name'] for number in self.groups[group_name]]
        return []

    def find_by_tag(self, tag_name):
        if tag_name in self.tags:
            return [self.contacts[number]['name'] for number in self.tags[tag_name]]
        return []

    def find_partial(self, partial_number):
        result = []
        for number in self.contacts:
            if str(number).startswith(partial_number):
                result.append((number, self.contacts[number]['name']))
        return result


def process_requests(requests):
    phone_book = PhoneBook()
    results = []
    for request in requests:
        query = request.split()
        if query[0] == "add":
            number, name = query[1], query[2]
            group = query[3] if len(query) > 3 else None
            phone_book.add_contact(number, name, group)
        elif query[0] == "del":
            number = query[1]
            phone_book.delete_contact(number)
        elif query[0] == "find":
            if len(query) == 2:
                number = query[1]
                results.append(phone_book.find_contact(number))
            elif query[1] == "partial":
                partial_number = query[2]
                matches = phone_book.find_partial(partial_number)
                if matches:
                    results.extend([f"{number}: {name}" for number, name in matches])
                else:
                    results.append("not found")
        elif query[0] == "tag":
            number, tag_name = query[1], query[2]
            phone_book.add_tag(number, tag_name)
        elif query[0] == "find_by_group":
            group_name = query[1]
            names = phone_book.find_by_group(group_name)
            results.append(", ".join(names) if names else "not found")
        elif query[0] == "find_by_tag":
            tag_name = query[1]
            names = phone_book.find_by_tag(tag_name)
            results.append(", ".join(names) if names else "not found")
    return results


def main():
    q = int(input())
    requests = []
    for _ in range(q):
        requests.append(input())
    results = process_requests(requests)
    print("\n".join(results))


if __name__ == "__main__":
    main()
