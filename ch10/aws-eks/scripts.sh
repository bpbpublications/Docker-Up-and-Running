aws cloudformation create-stack \
  --region eu-central-1 \
  --stack-name my-eks-vpc-stack \
  --template-url https://amazon-eks.s3.us-west-2.amazonaws.com/cloudformation/2020-10-29/amazon-eks-vpc-private-subnets.yaml

aws iam create-role \
  --role-name myAmazonEKSClusterRole \
  --assume-role-policy-document file://"cluster-role-trust-policy.json"

aws iam attach-role-policy \
  --policy-arn arn:aws:iam::aws:policy/AmazonEKSClusterPolicy \
  --role-name myAmazonEKSClusterRole

aws eks update-kubeconfig \
  --region eu-central-1 \
  --name My-cluster
