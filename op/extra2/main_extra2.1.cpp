#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <map>
#include <set>
#include <iomanip>
#include <stdexcept>

struct Expense {
    std::string name;
    double amount;
    std::set<std::string> excluded;
};

std::vector<std::string> readParticipants(const std::string &filename) {
    std::ifstream file(filename);
    std::vector<std::string> participants;
    std::string name;
    while (std::getline(file, name)) {
        participants.push_back(name);
    }
    return participants;
}

std::vector<Expense> readExpenses(const std::string &filename) {
    std::ifstream file(filename);
    std::vector<Expense> expenses;
    std::string line;
    while (std::getline(file, line)) {
        std::istringstream iss(line);
        Expense expense;
        std::getline(iss, expense.name, ':');
        iss >> expense.amount;
        std::string excluded;
        if (iss >> excluded) {
            if (excluded.size() > 2) { // Ensure there is enough length to substr
                excluded = excluded.substr(2); // Удаляем " /"
                std::istringstream excl(excluded);
                std::string name;
                while (std::getline(excl, name, ',')) {
                    expense.excluded.insert(name);
                }
            }
        }
        expenses.push_back(expense);
    }
    return expenses;
}

std::map<std::string, double>
calculateTotalExpenses(const std::vector<std::string> &participants, const std::vector<Expense> &expenses) {
    std::map<std::string, double> totalExpenses;
    for (const auto &participant : participants) {
        totalExpenses[participant] = 0.0;
    }

    for (const auto &expense : expenses) {
        double sharedAmount = expense.amount / (participants.size() - expense.excluded.size());
        for (const auto &participant : participants) {
            if (expense.excluded.find(participant) == expense.excluded.end()) {
                totalExpenses[participant] += sharedAmount;
            }
        }
    }

    return totalExpenses;
}

std::map<std::string, double>
calculateBalances(const std::vector<std::string> &participants, const std::vector<Expense> &expenses,
                  const std::map<std::string, double> &totalExpenses) {
    std::map<std::string, double> balances;
    for (const auto &participant : participants) {
        balances[participant] = -totalExpenses.at(participant);
    }

    for (const auto &expense : expenses) {
        balances[expense.name] += expense.amount;
    }

    return balances;
}

std::vector<std::tuple<std::string, std::string, double>>
calculateTransactions(const std::map<std::string, double> &balances) {
    std::vector<std::tuple<std::string, std::string, double>> transactions;
    std::multimap<double, std::string> creditors;
    std::multimap<double, std::string> debtors;

    for (const auto&[name, balance] : balances) {
        if (balance > 0) {
            creditors.emplace(balance, name);
        } else if (balance < 0) {
            debtors.emplace(-balance, name);
        }
    }

    while (!creditors.empty() && !debtors.empty()) {
        auto credit = creditors.begin();
        auto debit = debtors.begin();

        double amount = std::min(credit->first, debit->first);
        transactions.emplace_back(debit->second, credit->second, amount);

        if (credit->first > amount) {
            creditors.emplace(credit->first - amount, credit->second);
        }
        creditors.erase(credit);

        if (debit->first > amount) {
            debtors.emplace(debit->first - amount, debit->second);
        }
        debtors.erase(debit);
    }

    return transactions;
}

void printTotalExpenses(const std::map<std::string, double> &totalExpenses) {
    std::cout << "Total Expenses:\n";
    for (const auto &entry : totalExpenses) {
        std::cout << entry.first << ": " << std::fixed << std::setprecision(2) << entry.second << "\n";
    }
}

void printBalances(const std::map<std::string, double> &balances) {
    std::cout << "\nBalances:\n";
    for (const auto &entry : balances) {
        std::cout << entry.first << ": " << std::fixed << std::setprecision(2) << entry.second << "\n";
    }
}

void printTransactions(const std::vector<std::tuple<std::string, std::string, double>> &transactions) {
    std::cout << "\nTransactions:\n";
    for (const auto&[debtor, creditor, amount] : transactions) {
        std::cout << debtor << " -> " << creditor << ": " << std::fixed << std::setprecision(2) << amount << "\n";
    }
}

int main() {
    // Replace "participants.txt" and "expenses.txt" with actual file paths
    std::vector<std::string> participants = readParticipants(
            "/home/grigorijtomczuk/Desktop/suai/op/extra2/participants.txt");
    std::vector<Expense> expenses = readExpenses("/home/grigorijtomczuk/Desktop/suai/op/extra2/expenses.txt");

    std::map<std::string, double> totalExpenses = calculateTotalExpenses(participants, expenses);
    printTotalExpenses(totalExpenses);

    std::map<std::string, double> balances = calculateBalances(participants, expenses, totalExpenses);
    printBalances(balances);

    std::vector<std::tuple<std::string, std::string, double>> transactions = calculateTransactions(balances);
    printTransactions(transactions);

    return 0;
}
