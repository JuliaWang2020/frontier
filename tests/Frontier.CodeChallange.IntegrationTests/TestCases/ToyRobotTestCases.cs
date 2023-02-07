using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.IntegrationTests.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.IntegrationTests.TestCases
{
    public class ToyRobotTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetFirstPlaceOnTableTestCase();
            yield return GetMoveShouldBeBlockedCase();

        }

        private object[] GetMoveShouldBeBlockedCase()
        {
            return new object[]
            {
                 new ToyRobotTestCase
                 {
                     Inputs = new List<CommandWithResponse>
                     {
                        new CommandWithResponse
                        {
                            InputCommand = "place(4,3,NORTH)",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Success
                            }
                        },
                        new CommandWithResponse
                        {
                            InputCommand = "move()",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Success
                            }
                        },
                        new CommandWithResponse
                        {
                            InputCommand = "move()",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Ignore,
                                Message = "Blocked"
                            }
                        },
                     },
                      TestName = "Toy Robot should be blocked when moving to edge"
                 }
            };
        }

        private object[] GetFirstPlaceOnTableTestCase()
        {
            return new object[]
            {
                new ToyRobotTestCase
                {
                    Inputs = new List<CommandWithResponse>
                    {
                        new CommandWithResponse
                        {
                            InputCommand = "left()",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Ignore
                            }
                        },
                        new CommandWithResponse
                        {
                            InputCommand = "place(1,1,EAST)",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Success
                            }
                        },
                        new CommandWithResponse
                        {
                            InputCommand = "left()",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Success
                            }
                        },
                        new CommandWithResponse
                        {
                            InputCommand = "report()",
                            ExpectedReponse = new CommandResponse
                            {
                                Status = ResponseStatus.Success,
                                Message = "1,1,NORTH"
                            }
                        }
                    },
                    TestName = "Other Command need wait for Place on table"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
